include Makefile.helpers
modname = CrusadersEquipment
exports = resources/artsource/exports
unityassets = resources/unity/HolyAvengerBastard/Assets
unityassetbundles = resources/unity/HolyAvengerBastard/Assets/AssetBundles

dependencies = BaseDamageModifiers EffectSourceConditions HolyDamageManager ImpendingDoom Proficiencies RelicCondition SynchronizedWorldObjects TinyHelper


assemble:
	# common for all mods
	rm -f -r public
	@make dllsinto TARGET=$(modname) --no-print-directory
	
	@make basefolders
	
	@make item NAME="AncientRelic" FILENAME="ancient_relic"
	@make itemtextured NAME="RangerBoots" FILENAME="ranger_boots" MATERIALNAME="mat_cha_masterTrader"
	@make itemtextured NAME="WolfRangerArmor" FILENAME="wolf_ranger_armor" MATERIALNAME="mat_cha_WolfBattleMedicArmor" PROPERTIES="properties_color_spec"
	@make itemtextured NAME="OldDesertTunic" FILENAME="old_desert_tunic" MATERIALNAME="mat_cha_desertArmor"
	@make itemtextured NAME="CharredHood" FILENAME="charred_hood" MATERIALNAME="mat_cha_beggarMaleArmorA"
	@make itemtextured NAME="RangersHood" FILENAME="rangers_hood" MATERIALNAME="mat_cha_beggarMaleArmorA" ICONNAME="ranger_hood"
	@make itemtextured NAME="CrusadersPlateArmor" FILENAME="crusaders_plate_armor" MATERIALNAME="mat_cha_runicArmor"
	@make itemtextured NAME="CrusadersArmor" FILENAME="crusaders_armor" MATERIALNAME="mat_cha_armorKaziteA"
	@make itemtextured NAME="CrusadersBoots" FILENAME="crusaders_boots" MATERIALNAME="mat_cha_whitePriestArmor"
	@make itemtextured NAME="CrusadersHood" FILENAME="crusaders_hood" MATERIALNAME="mat_cha_beggarMaleArmorA"
	@make itemtextured NAME="CrusadersRoundShield" FILENAME="crusaders_round_shield" MATERIALNAME="mat_itm_boneWeapons"
	@make itemtextured NAME="CrusadersShield" FILENAME="crusaders_shield" MATERIALNAME="mat_cha_crimsonPlateArmor"
	@make itemtextured NAME="HeavyPlateArmor" FILENAME="heavy_plate_armor" MATERIALNAME="mat_cha_plateArmorPlain" PROPERTIES="properties_color_spec" FILEPATH="$(exports)/heavy_plate_armor/"
	@make item NAME="GoldRing" FILENAME="gold_ring"
	@make item NAME="FaraamHelmet" FILENAME="faraam_helmet"
	@make item NAME="GnarledStaff" FILENAME="gnarled_staff"
	@make item NAME="FaraamLongsword" FILENAME="faraam_longsword"
	@make item NAME="CorruptedLongsword" FILENAME="corrupted_longsword"
	@make item NAME="PuresteelLongsword" FILENAME="holy_avenger_no_inscription"
	@make item NAME="HolyWater" FILENAME="holy_water"
	@make item NAME="SoulIncense" FILENAME="soul_incense"
	@make itemtextured NAME="ThickWhitePaint" FILENAME="thick_white_paint" MATERIALNAME="mat_env_propSlimeVilePus"
	@make itemtextured NAME="ZealotsArmor" FILENAME="zealots_armor" MATERIALNAME="mat_cha_krypteiaarmor" SPECCOLORTEX="zealots_armor_spec"
	@make texture PREPATH="../ImpendingDoom/" FILENAME="ImpendingDoomIcon"
	@make assetbundle FILENAME="gnarled_staff"
	@make assetbundle FILENAME="faraam_longsword"
	@make assetbundle FILENAME="faraam_helmet"
	@make assetbundle FILENAME="corrupted_longsword"
	@make assetbundle FILENAME="puresteel_longsword"
	@make assetbundle FILENAME="gold_ring"

unity:
	cp resources/artsource/gnarled_staff.fbx                                        $(unityassets)/gnarled_staff.fbx
	cp resources/artsource/puresteel_longsword.fbx                                  $(unityassets)/puresteel_longsword.fbx
	cp resources/artsource/faraam_longsword.fbx                                     $(unityassets)/faraam_longsword.fbx
	cp resources/artsource/faraam_helmet.fbx                                        $(unityassets)/faraam_helmet.fbx
	cp resources/artsource/corrupted_longsword.fbx                                  $(unityassets)/corrupted_longsword.fbx
	cp resources/artsource/gold_ring.fbx                                            $(unityassets)/gold_ring.fbx
	cp $(exports)/gnarled_staff/gnarled_staff_AlbedoTransparency.png          $(unityassets)/gnarled_staff_AlbedoTransparency.png
	cp $(exports)/gnarled_staff/gnarled_staff_MetallicSmoothness.png          $(unityassets)/gnarled_staff_MetallicSmoothness.png
	cp $(exports)/gnarled_staff/gnarled_staff_Normal.png                      $(unityassets)/gnarled_staff_Normal.png
	cp $(exports)/faraam_longsword/faraam_longsword_AlbedoTransparency.png          $(unityassets)/faraam_longsword_AlbedoTransparency.png
	cp $(exports)/faraam_longsword/faraam_longsword_MetallicSmoothness.png          $(unityassets)/faraam_longsword_MetallicSmoothness.png
	cp $(exports)/faraam_longsword/faraam_longsword_Normal.png                      $(unityassets)/faraam_longsword_Normal.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_AlbedoTransparency.png    $(unityassets)/corrupted_longsword_AlbedoTransparency.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_MetallicSmoothness.png    $(unityassets)/corrupted_longsword_MetallicSmoothness.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_Normal.png                $(unityassets)/corrupted_longsword_Normal.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_AlbedoTransparency.png    $(unityassets)/puresteel_longsword_AlbedoTransparency.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_MetallicSmoothness.png    $(unityassets)/puresteel_longsword_MetallicSmoothness.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_Normal.png                $(unityassets)/puresteel_longsword_Normal.png
	cp $(exports)/gold_ring/gold_ring_AlbedoTransparency.png                        $(unityassets)/gold_ring_AlbedoTransparency.png
	cp $(exports)/gold_ring/gold_ring_MetallicSmoothness.png                        $(unityassets)/gold_ring_MetallicSmoothness.png
	cp $(exports)/gold_ring/gold_ring_Normal.png                                    $(unityassets)/gold_ring_Normal.png
	
forceinstall:
	make assemble
	rm -r -f $(gamepath)/$(pluginpath)/$(modname)
	cp -u -r public/* $(gamepath)

play:
	(make install && cd .. && make play)

backup:
	mkdir -p ../../OutwardModdingGraphicsBackup/resources/artsource
	mkdir -p ../../OutwardModdingGraphicsBackup/resources/icons
	cp -u resources/artsource/*.blend ../../OutwardModdingGraphicsBackup/resources/artsource
	cp -u resources/artsource/*.spp ../../OutwardModdingGraphicsBackup/resources/artsource
	cp -u resources/icons/*.pdn ../../OutwardModdingGraphicsBackup/resources/icons
