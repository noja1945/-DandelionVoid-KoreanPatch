-- Dandelion Void unofficial Korean patch
-- Registers the ko-KR language without modifying the game's original files.
-- Safe to delete: removing this file (and ko-KR_1.csv) removes Korean from the language list.

local function register_korean()
    if not (localization and localization.supported_languages) then
        return false
    end
    localization.supported_languages["ko-KR"] =
    {
        code = "ko-KR",
        friendly_name = "t_uiux_settings_language_ko-KR",
        unity_system_languages = {"Korean"},
        sort_order = 8,
    }
    return true
end

if register_korean() then
    -- If the localization sheets were already requested before this mod file ran,
    -- request the Korean sheets now as well (loading twice is harmless).
    pcall(function()
        if assets and assets.cs_instance and localization.sheet_version_suffixes then
            for _, suffix in ipairs(localization.sheet_version_suffixes) do
                assets.get_csv(
                    {
                        path = "ko-KR"..suffix..".csv",
                        done = function(csv) localization.on_initialize_csv(csv, "ko-KR") end,
                    }
                )
            end
        end
    end)
    pcall(function()
        if configs and configs.get_language_code then
            localization.selected_language = configs.get_language_code()
        end
    end)
    print("[Korean patch] ko-KR language registered")
else
    print_error = print_error or print
    print_error("[Korean patch] localization table not ready; Korean not registered")
end
